var firstname = document.getElementsByName("FirstName");
var lasttname = document.getElementsByName("LastName");
var userID = document.getElementsByName("UserID");
var password = document.getElementsByName("Password");
var email = document.getElementsByName("Email");

function validateForm() {
  var fn = document.forms["signupForm"]["FirstName"].value;
  var ln = document.forms["signupForm"]["LastName"].value;
  var ui = document.forms["signupForm"]["UserID"].value;
  var pw = document.forms["signupForm"]["PasswordID"].value;
  var em = document.forms["signupForm"]["Email"].value;
  
  if (  fn == "" || 
  fn == null ||
  fn == undefined) 
  {
    alert("First Name must be filled out");
    return false;
  }
  if (  ln == "" || 
  ln == null ||
  ln == undefined) 
  {
    alert("Last Name must be filled out");
    return false;
  }
  if (  ui == "" || 
  ui == null ||
  ui == undefined) 
  {
    alert("User Name must be filled out");
    return false;
  }
  if (  pw == "" || 
  pw == null ||
  pw == undefined) 
  {
    alert("Password must be filled out");
    return false;
  }
  if (  em == "" || 
  em == null ||
  em == undefined) 
  {
    alert("@Email must be filled out");
    return false;
  }
}