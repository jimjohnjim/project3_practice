document.getElementsByName("room").forEach(item => {
  item.addEventListener("click",function(){
    sessionStorage.setItem('room',item.value)
  })
})