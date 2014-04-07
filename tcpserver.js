var net = require('net');
var JSON = require('JSON');
var fs = require('fs');

var HOST = '127.0.0.1';
var PORT = 3000;

var input = "";
var items = fs.readFileSync('items.txt').toString().split("\n");

var bid1 = 0.00;
var bid2 = 0.00;
var bid3 = 0.00;
var bid4 = 0.00;

var win1 = "";
var win2 = "";
var win3 = "";
var win4 = "";

var server = net.createServer();
server.listen(PORT, HOST);
console.log('Server listening on ' + HOST +':'+ PORT);
console.log('');

server.on('connection', function(sock) {
	console.log('CONNECTED: ' + sock.remoteAddress +':'+ sock.remotePort);
	var username = "";
	sock.on('data', dataIn); 
	sock.on('close', function(data) {
		console.log('CLOSED: ' + username);
	});
	function dataIn(data) {
		console.log('Data received: ' + data);
		input = String(data);
		if (input.indexOf("OAP") == 0){
			console.log('Acceptable transmission!');
			if (input.indexOf("JOIN") == 4){
				//user has logged in!
				username = input.substring(14, input.lastIndexOf("\""));
				console.log('Username is ' + username);
				for(i in items){
					sock.write(items[i]);
				}
				bid1 = parseFloat(items[0].substring(items[0].indexOf('~')+1, items[0].indexOf('~', items[0].indexOf('~')+1)-1));
				bid2 = parseFloat(items[1].substring(items[1].indexOf('~')+1, items[1].indexOf('~', items[1].indexOf('~')+1)-1));
				bid3 = parseFloat(items[2].substring(items[2].indexOf('~')+1, items[2].indexOf('~', items[2].indexOf('~')+1)-1));
				bid4 = parseFloat(items[3].substring(items[3].indexOf('~')+1, items[3].indexOf('~', items[3].indexOf('~')+1)-1));
			}
			else if(input.indexOf("BID") == 4){
				var bid = parseFloat(input.substring(input.lastIndexOf('=') + 1));
				if (input.substring(input.indexOf('=')+1, input.indexOf('=')+2) == "1"){
					console.log("Bid on item 1: " + bid);
					if (bid > bid1){
						bid1 = bid;
						win1 = input.substring(input.indexOf('r=')+2, input.lastIndexOf('Bid'));
						console.log("New leader is " + win1);
						sock.write("LEAD");
					}
					else{
						sock.write("FAIL:" + bid1);
					}
				}
				else if (input.substring(input.substring(input.indexOf('=')+1, input.indexOf('=')+2) == "2")){
					console.log("Bid on item 2: " + bid);
					if (bid > bid2){
						bid2 = bid;
						win2 = input.substring(input.indexOf('r=')+2, input.lastIndexOf('Bid'));
						console.log("New leader is " + win2);
						sock.write("LEAD");
					}
					else{
						sock.write("FAIL:" + bid2);
					}
				}
				else if (input.substring(input.substring(input.indexOf('=')+1, input.indexOf('=')+2) == "3")){
					console.log("Bid on item 3: " + bid);
					if (bid > bid3){
						bid3 = bid;
						win3 = input.substring(input.indexOf('r=')+2, input.lastIndexOf('Bid'));
						console.log("New leader is " + win3);
						sock.write("LEAD");
					}
					else{
						sock.write("FAIL:" + bid3);
					}
				}
				else if (input.substring(input.substring(input.indexOf('=')+1, input.indexOf('=')+2) == "4")){
					console.log("Bid on item 4: " + bid);
					if (bid > bid4){
						bid4 = bid;
						win4 = input.substring(input.indexOf('r=')+2, input.lastIndexOf('Bid'));
						console.log("New leader is " + win4);
						sock.write("LEAD");
					}
					else{
						sock.write("FAIL:" + bid4);
					}
				}
			}
		}
	}
});