
let field = document.getElementById("Username");

field.addEventListener("change",function(){
  sessionStorage.setItem('name',field.value);
});