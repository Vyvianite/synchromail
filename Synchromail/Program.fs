namespace Synchromail

open Tomlet

module Program =

  [<EntryPoint>]
  let main argv =
    try
      let config = "config.toml" |> TomlParser.ParseFile |> TomletMain.To<Config>

      //Set up infrastructure and email api

      //printfn $"{TomletMain.TomlStringFrom tomlRead}"
      0
    with 
      | _ -> 1 //TODO Error handling and logging
