namespace Synchromail

module Parse =

  ///Takes a seq of emails and the rules to validate those emails, and returns the emails that should become tickets
  let parse (emails: Email seq) (rules: Rule array) : Email seq =
    ()
