function fib(){
  // Some variables here
  var counter = 0;
  var counter2 = 1;

  function nacci() {
    // do something to those variables here
    console.log(counter2)
    var temp = counter;
    counter = counter2;
    counter2 = counter + temp;
  }

  return nacci
}
var fibCounter = fib();
fibCounter() // should console.log "1"
fibCounter() // should console.log "1"
fibCounter() // should console.log "2"
fibCounter() // should console.log "3"
fibCounter() // should console.log "5"
fibCounter() // should console.log "8"
