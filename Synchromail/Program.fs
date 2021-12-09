namespace Synchromail

open Tomlet
open MailKit.Net.Imap

module Program =

  [<EntryPoint>]
  let main argv =
    try
      let rules, mConf, sConf = 
        let config = "config.toml" |> TomlParser.ParseFile |> TomletMain.To<Config>
        config.Rules, config.Mail, config.Synchro

      use mailApi =
        match MailApi.tryCreate mConf with
        | Ok x -> x
        | _ as x -> failwith "Failed to connect." //HACK there's gotta be a better way to do this, i'm just too tired to see it. maybe

      let unread = mailApi.getUnread ()


      //printfn $"{TomletMain.TomlStringFrom tomlRead}"
      0
    with 
      | _ as z -> 1 //TODO Error handling and logging
