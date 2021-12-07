namespace Synchromail

type Config() = 
  [<DefaultValue>] val mutable Mail : Mail
  [<DefaultValue>] val mutable Synchro : Synchro
  [<DefaultValue>] val mutable Rules : Rule array

and //Too unidiomatic? I think it reads better this way, but it may just be confusing
  Rule() = 
    [<DefaultValue>] val mutable Sender : string
    [<DefaultValue>] val mutable Blocked : string array
    [<DefaultValue>] val mutable Allowed : string array

and
  Mail() =
    [<DefaultValue>] val mutable Server : string
    [<DefaultValue>] val mutable Port : int
    [<DefaultValue>] val mutable Username : string
    [<DefaultValue>] val mutable Password : string

and
  Synchro() =
    [<DefaultValue>] val mutable Key : string