// assume jQuery is loaded

function registerHandlers() {
  var as = $('a');
  for (var i = 0; i < as.length; i++) {
    $(as[i]).on('click', { number: i }, function(event) {
      alert(event.data.number);
      return false;
    });
  }
}