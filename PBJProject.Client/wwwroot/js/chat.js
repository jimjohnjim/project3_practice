"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

connection.start();



document.getElementsByName("room").forEach(item => {
  item.addEventListener("click",function(){
    sessionStorage.setItem('room',item.value)
    connection.invoke("JoinRoom",sessionStorage.getItem("name"), sessionStorage.getItem("room"));
  })
})


connection.on("ReceiveMessage", function (user, message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = user + ": " + msg;
    var li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("messagesList").appendChild(li);
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = sessionStorage.getItem('name');
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
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