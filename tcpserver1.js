var net = require('net');

var HOST = '127.0.0.1';
var PORT = 3000;

var server = net.createServer();
server.listen(PORT, HOST);
console.log('Server listening on ' + HOST +':'+ PORT);
server.on('connection', function(sock) {
	console.log('CONNECTED: ' + sock.remoteAddress +':'+ sock.remotePort);
	
	sock.on('data', readRespond);
	sock.on('close', function(data) {
		console.log('CLOSED: ' + sock.remoteAddress +' '+ sock.remotePort);
	});
	function readRespond(data) {
		console.log('DATA ' + sock.remoteAddress + ': ' + data);
		sock.write('You said "' + data + '"'); 
	}
});