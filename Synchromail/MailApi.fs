namespace Synchromail

open System
open MailKit
open MailKit.Net.Imap
open MailKit.Search
open System.Linq
open MimeKit

type Email = 
  { Sender : string
  ; Subject : string
  ; Body : string
  ; Uid : UniqueId }

module MailApi = 
  let get (client: ImapClient) config : Email seq = 
    let ({Server = server; Port = port; Username = user; Password = pass}: Mail) = config
    client.Connect (server, port, true)
    client.Authenticate (user, pass)

    let inbox = client.Inbox
    ignore <| inbox.Open FolderAccess.ReadWrite

    let uids = inbox.Search SearchQuery.NotSeen

    let unread  =  
      uids
      |> Seq.map (fun x -> inbox.GetMessage x, x) //Uid is tupled with the resulting emails
      |> Seq.map (fun (x, uid) ->
          { Sender = (Seq.head x.From.Mailboxes).Address
          ; Subject = x.Subject
          ; Body = 
              if isNull x.TextBody then //To prevent massive html dumps into a ticket. Better solution?
                "Email contained Html only." 
              else x.TextBody 
          ; Uid = uid })

    inbox.AddFlags (uids, MessageFlags.Seen, true);
    //inbox.MoveTo (uids, ...)
    client.Disconnect true
    unread

  //Move to archive folder?
  let update client config emailList =
    ()



// (*The first item in the bodyparts list is the text/plain if it's there*)
// (Seq.head (x.BodyParts.OfType<TextPart> ())).Text

//Am I horribly overcomplicating this? I could totally just do this whole workflow in a one-off function
//Yes, yes I am
///Creates and initializes the connction to specified imap server. Can throw.
//type MailApi (mail) =
//  let ({Server = server; Port = port; Username = user; Password = pass}: Mail) = mail
//  let client = new ImapClient ()
//  do
//    client.Connect (server, port, true)
//    client.Authenticate (user, pass)

//  member _.getUnread () = 
//    let a = server 
//    client //do stuff

//  interface IDisposable with
//    member _.Dispose () = client.Dispose ()