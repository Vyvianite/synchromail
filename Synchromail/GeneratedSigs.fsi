



namespace Synchromail
    
    type Config =
        
        new: unit -> Config
        
        [<DefaultValue>]
        val mutable Mail: Mail
        
        [<DefaultValue>]
        val mutable Synchro: Synchro
        
        [<DefaultValue>]
        val mutable Rules: Rule array
    
    and Rule =
        
        new: unit -> Rule
        
        [<DefaultValue>]
        val mutable Sender: string
        
        [<DefaultValue>]
        val mutable Blocked: string array
        
        [<DefaultValue>]
        val mutable Allowed: string array
    
    and Mail =
        
        new: unit -> Mail
        
        [<DefaultValue>]
        val mutable Server: string
        
        [<DefaultValue>]
        val mutable Port: int
        
        [<DefaultValue>]
        val mutable Username: string
        
        [<DefaultValue>]
        val mutable Password: string
    
    and Synchro =
        
        new: unit -> Synchro
        
        [<DefaultValue>]
        val mutable Key: string

namespace Synchromail
    
    type Email =
        {
          Sender: string
          Subject: string
          Body: string
          Uid: MailKit.UniqueId
        }
    
    module MailApi =
        
        val get:
          client: MailKit.Net.Imap.ImapClient -> config: Mail -> seq<Email>
        
        val update: client: 'a -> config: 'b -> emailList: 'c -> unit

namespace Synchromail
    
    module Program =
        
        val main: argv: string[] -> int

