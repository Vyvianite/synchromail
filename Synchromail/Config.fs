namespace Synchromail

type Config() = 
  [<DefaultValue>] val mutable Server : string
  [<DefaultValue>] val mutable Port : int
  [<DefaultValue>] val mutable Username : string
  [<DefaultValue>] val mutable Password : string
  [<DefaultValue>] val mutable Rules : Rule array

and 
  Rule() = //Too unidiomatic? I think it reads better this way, but it may just be confusing
    [<DefaultValue>] val mutable Sender : string
    [<DefaultValue>] val mutable Blocked : string array
    [<DefaultValue>] val mutable Allowed : string array