
let field = document.getElementById("Email");

field.addEventListener("change",function(){
  sessionStorage.setItem('name',field.value);
});