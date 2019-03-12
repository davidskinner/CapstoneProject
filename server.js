var five = require("johnny-five");
const dweetClient = require('node-dweetio');

var board = new five.Board();
const dweetio = new dweetClient();

//Global variables 
var data = [];
var bodyCount = 0;

//Meta-Parameters
var cases = 10;
var Threshold = 50;
var OuterCase = 200;
var InnerCase = 50;

//Function to check if someone is there 
function checkPerson(){
	var sum = 0;
	const dweetThing = 'node-person-monitor';

	
	//Check to see if Cases have been acquired
	if(data.length > cases){
		
		//Get previous cases
		for(let i = 0; i < data.length - 2; i++){
			sum = sum + data[i];
		}		
		
		//Calculate Delta
		var change = (data[data.length - 2] - data[0]) %1;		
		
		//Check if change is past threshold
		if(sum/(cases - 1) - data[data.length - 2] > Threshold && data[data.length - 2] < OuterCase){
			//Add to count if they are moving towards
			if(change < 0 && InnerCase < data[data.length - 2]){
				bodyCount = 1;
				console.log("New Person Found! Total People: " + bodyCount);
			}
			//else delete
			else if(InnerCase > data[data.length - 2]){
				if(bodyCount > 0){
					bodyCount = - 1;
					console.log("Person Left! Total People: " + bodyCount);
				}
			}
			
			const tweetMessage = {
				People: bodyCount
			};
			
			dweetio.dweet_for(dweetThing, tweetMessage, (err, dweet) => {
				if (err) {
				console.log('[Error]: ', err);
				}
				if (dweet) {
				console.log(dweet.content);
				}
			});
			//Get rid of extraneous data
			data.splice(0,data.length - 2);
		}
		
		/*else if(sum/(cases - 1) - data[data.length - 2] > Threshold && data[data.length - 2] < OuterCase){
			console.log("LEaving");
		}*/
		else //shift data by one 
			data.shift();
	}
}

//Set board presets
board.on("ready", function() {
  var proximity = new five.Proximity({
    controller: "PING_PULSE_IN",
    pin: 7
  });

  //Catch Change
  proximity.on("change", function() {
	data.push(this.cm);
	checkPerson();
	});
});