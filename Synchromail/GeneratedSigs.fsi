



namespace Synchromail
    
    type Rule =
        
        new: unit -> Rule
        
        [<DefaultValue>]
        val mutable address: string
        
        [<DefaultValue>]
        val mutable blocked: string array
        
        [<DefaultValue>]
        val mutable allowed: string array
    
    type Config =
        
        new: unit -> Config
        
        [<DefaultValue>]
        val mutable mailbox: string
        
        [<DefaultValue>]
        val mutable username: string
        
        [<DefaultValue>]
        val mutable password: string

namespace Synchromail
    
    module Toml =
        
        val g: a: 'a -> string

namespace Synchromail
    
    module Program =
        
        val main: argv: string[] -> int

