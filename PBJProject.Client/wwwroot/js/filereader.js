"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/fileHub").build();

connection.start().then(function () {
  console.log("connected");
});

window.onload = function() {
  var fileInput = document.getElementById('fileInput');
  var fileDisplayArea = document.getElementById('fileDisplayArea');
  console.log("got to here")

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

      connection.invoke("LoadFile", message).fail(function(error)
      {
        console.log('error:' + error)
      });

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