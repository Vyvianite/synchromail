namespace Synchromail

open Tomlet

module Program =

  [<EntryPoint>]
  let main argv =
    try
      let config = TomlParser.ParseFile("config.toml") |> TomletMain.To<Config>



      //printfn $"{TomletMain.TomlStringFrom tomlRead}"
      0
    with 
      | _ -> 1 //TODO Error handling and logging
