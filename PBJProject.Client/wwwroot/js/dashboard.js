let field = document.getElementById("room");

field.addEventListener("click",function(){
  sessionStorage.setItem('room',field.value);
});