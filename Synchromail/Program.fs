namespace Synchromail

open Tomlet
open MailKit.Net.Imap

module Program =

  [<EntryPoint>]
  let main argv =
    try
      let config = "config.toml" |> TomlParser.ParseFile |> TomletMain.To<Config>

      use client = new ImapClient ()
      let a = new MailApi (client, config)

      (* How i want the api to be used
      use client = new ImapClient ()
      let api = MailApi (client, config)
      api.get ()
      |>  Rule.filter
      |> api.update
      *)

      //printfn $"{TomletMain.TomlStringFrom tomlRead}"
      0
    with 
      | _ as z -> 1 //TODO Error handling and logging
