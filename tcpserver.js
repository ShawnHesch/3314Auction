var net = require('net');
var JSON = require('JSON');
var fs = require('fs');

var HOST = '127.0.0.1';
var PORT = 3000;

var username = "";

var input = "";
var items = fs.readFileSync('items.txt').toString().split("\n");

var server = net.createServer();
server.listen(PORT, HOST);
console.log('Server listening on ' + HOST +':'+ PORT);
console.log('');

server.on('connection', function(sock) {
	console.log('CONNECTED: ' + sock.remoteAddress +':'+ sock.remotePort);
	
	sock.on('data', dataIn); 
	sock.on('close', function(data) {
		console.log('CLOSED: ' + username);
	});
	function dataIn(data) {
		console.log('Data received: ' + data);
		input = String(data);
		console.log('Data received: ' + input);
		if (input.indexOf("OAP") == 0){
			console.log('Acceptable transmission!');
			if (input.indexOf("JOIN") == 4){
				//user has logged in!
				username = input.substr(9, input.lastIndexOf("\""));
				console.log('Username is ' + username);
				sock.write('OAP WLECOME');
				for(i in items){
					sock.write(items[i]);
				}
			}
		}
	}
});