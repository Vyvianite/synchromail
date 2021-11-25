namespace Synchromail

type Rule() = 
  [<DefaultValue>] val mutable address : string
  [<DefaultValue>] val mutable blocked : string array
  [<DefaultValue>] val mutable allowed : string array

type Config() = 
  [<DefaultValue>] val mutable mailbox : string;
  [<DefaultValue>] val mutable username : string;
  [<DefaultValue>] val mutable password : string;
  [<DefaultValue>] val mutable rules : Rule array

