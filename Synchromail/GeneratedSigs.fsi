



namespace Synchromail
    
    type Config =
        
        new: unit -> Config
        
        [<DefaultValue>]
        val mutable Server: string
        
        [<DefaultValue>]
        val mutable Port: int
        
        [<DefaultValue>]
        val mutable Username: string
        
        [<DefaultValue>]
        val mutable Password: string
        
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

namespace Synchromail
    
    type Email =
        {
          subject: string
          body: string
        }
    
    ///<summary>
    ///Creates and initializes the connction to specified imap server
    ///<c>can fail</c>
    ///</summary>
    ///<exception>Can fail</exception> 
    ///<returns>fail</returns>
    type MailApi =
        
        new: client: MailKit.Net.Imap.ImapClient * config: Config -> MailApi
        
        member getUnread: unit -> MailKit.Net.Imap.ImapClient

namespace Synchromail
    
    module Program =
        
        val main: argv: string[] -> int

