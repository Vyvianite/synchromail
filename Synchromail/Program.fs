namespace Synchromail

open Tomlet
open MailKit.Net.Imap
open MailApi

module Program =

  [<EntryPoint>]
  let main argv =
    try
      let rules, mConf, sConf = 
        let config = "config.toml" |> TomlParser.ParseFile |> TomletMain.To<Config>
        config.Rules, config.Mail, config.Synchro

      use client = new ImapClient()
      let emails = get client mConf

      //parse here

      update client mConf emails

      //printfn $"{TomletMain.TomlStringFrom tomlRead}"
      0
    with 
      | _ as z -> 1 //TODO Error handling and logging
