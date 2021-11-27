namespace Synchromail

open MailKit
open MailKit.Net.Imap

type Email = 
  { subject : string
  ; body : string }

///Creates and initializes the connction to specified imap server. Can throw.
type MailApi (client: ImapClient, config: Config) =
  let ({Server = server; Port = port; Username = user; Password = pass}: Config) = config
  do
    client.Connect (server, port, true)
    client.Authenticate (user, pass)

  member x.getUnread () = 
    let a = server 
    client //do stuff