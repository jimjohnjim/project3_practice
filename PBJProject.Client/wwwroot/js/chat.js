"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
connection.logging=true;

connection.onclose();


connection.start().then(function() {


document.getElementsByName("room").forEach(item => {
  item.addEventListener("click",function(){
    sessionStorage.setItem('room',item.value)
    connection.invoke("SwitchRoom").catch(err => console.error(err))
    connection.invoke("JoinRoom",sessionStorage.getItem("name"), sessionStorage.getItem("room")).catch(err => 
      console.error(err))
    });
  })

})


connection.on("ReceiveMessage", function (user, message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = user + ": " + msg;
    var li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("messagesList").appendChild(li);
});

document.getElementById("messageInput").addEventListener("keyup", function (event) {
  if(event.keyCode === 13){
    var user = sessionStorage.getItem('name');
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch( function (err) {
      return console.error(err.toString());
  });
  }
  event.preventDefault();
});

connection.on("DiceRoll", function(user,dice,sum,highest) {
  var message = user + " rolled";
  var i;

  for(i = 0; i < dice.length; i++)
  {
    message += " " + dice[i];
    if(i!=dice.length-1){
      message += ",";
    }
  }

  var encodedMsg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
  var li = document.createElement("li");
  li.textContent = encodedMsg;
  document.getElementById("messagesList").appendChild(li);
  if(dice.length > 1){
    var liSum = document.createElement("li");
    var liHigh = document.createElement("li");
    liSum.textContent = "Total: " + sum;
    document.getElementById("messagesList").appendChild(liSum);
    liHigh.textContent = "Highest: " + highest;
    document.getElementById("messagesList").appendChild(liHigh);
  }
  
})

connection.on("UserJoined", function (user, users) {
  var message = user + " has joined the party!";
  var encodedMsg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
  var li = document.createElement("li");
  li.textContent = encodedMsg;
  li.setAttribute("class","font-weight-bold");
  document.getElementById("messagesList").appendChild(li);
  SendUsers(users)
})

connection.on("UserLeft", function (user, users) {
  var message = "Adventurer " + user + " has fallen!";
  var encodedMsg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
  var li = document.createElement("li");
  li.textContent = encodedMsg;
  li.setAttribute("class","font-weight-bold");
  document.getElementById("messagesList").appendChild(li);
  SendUsers(users)
})

function SendUsers(users){
  var message = "Party size: " + users;
  var encodedMsg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
  var li = document.createElement("li");
  li.textContent = encodedMsg;
  li.setAttribute("class","font-weight-bold");
  document.getElementById("messagesList").appendChild(li);
}



window.onload = function() {
  var fileInput = document.getElementById('fileInput');
  var fileDisplayArea = document.getElementById('fileDisplayArea');

  fileInput.addEventListener('change', function(e) {
    var file = fileInput.files[0];
    var textType = "application/json";

    if (file.type.match(textType)) {
      var reader = new FileReader();

      reader.onload = function() {
        fileDisplayArea.innerText = reader.result;
      }
      parse(file).then((message) => {
        console.log(message);

      connection.invoke("LoadFile", message)

      });

    } else {
      fileDisplayArea.innerText = "File not supported!"
    }
  });
}

function parse(file) {
  return new Promise((resolve,reject) => {
    let content = '';
    const reader = new FileReader();

    reader.onloadend = function(e) {
      content = e.target.result;
      resolve(content);
    };

    reader.onerror = function (e) {
      reject(e);
    };

    reader.readAsText(file);
  });
}