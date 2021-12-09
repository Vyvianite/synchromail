﻿namespace Synchromail

open System
open MailKit
open MailKit.Net.Imap
open MailKit.Search

type Email = 
  { Sender: string
  ; Subject: string
  ; Body: string
  ; Uid: UniqueId }

///Wrapper type to handle the resources of an ImapClient
type MailApi private (client: ImapClient) =

  member _.getUnread () = 
    let inbox = client.Inbox
    ignore <| inbox.Open FolderAccess.ReadWrite

    let uids = inbox.Search SearchQuery.NotSeen

    let getEmail (uid: UniqueId) =
      try
        let x = inbox.GetMessage uid //Todo make async?
        { Sender = (Seq.head x.From.Mailboxes).Address
        ; Subject = x.Subject
        ; Body = 
            if isNull x.TextBody then //To prevent massive html dumps into a ticket. Better solution?
              "Email contained Html only." 
            else x.TextBody
        ; Uid = uid }
        |> Some
      with
      | _ as e -> None

    let unread  =  
      uids
      |> Seq.map getEmail
      |> Seq.choose id

    inbox.AddFlags (uids, MessageFlags.Seen, true);
    //inbox.MoveTo (uids, ...)
    unread

  member _.updateMail (mail: Email seq) : unit =
    ()

  static member tryCreate mailConf =
    let ({Server = server; Port = port; Username = user; Password = pass}: Mail) = mailConf
    let client = new ImapClient ()
    try
      client.Connect (server, port, true)
      client.Authenticate (user, pass)
      Ok <| new MailApi(client)
    with _ as x -> Error x

  interface IDisposable with
    member _.Dispose () = 
      client.Disconnect true
      client.Dispose ()

// (*The first item in the bodyparts list is the text/plain if it's there*)
// (Seq.head (x.BodyParts.OfType<TextPart> ())).Text