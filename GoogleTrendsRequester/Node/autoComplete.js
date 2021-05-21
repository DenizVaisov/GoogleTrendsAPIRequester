'use strict';
var googleTrends = require('./node_modules/google-trends-api/lib/google-trends-api.min.js');
function parseRequest(request) {
    request.startTime = new Date(request.startTime);
    request.endTime = new Date(request.endTime);
    return request;
}
module.exports = function (callback, request) {
	var autoCompleteRequest = parseRequest(request);
	googleTrends.autoComplete(autoCompleteRequest)
	.then((res) => {
		callback(null, res);
	})
	.catch((err) => {
		console.log('got the error', err);
		console.log('error message', err.message);
		console.log('request body', err.requestBody);
		callback(err.message, null);
	});
}