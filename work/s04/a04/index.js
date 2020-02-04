/**
 * A sample Express server.
 */
"use strict";

const port = process.env.DBWEBB_PORT || 1223;


const express = require("express");
const app = express();
var fs = require('fs');

app.get("/lotto", (req, res) => {
  res.writeHead(200,{'Content-Type': 'text/html'});
  var readStream= fs.createReadStream(__dirname +'/lotto.html','utf8');
  readStream.pipe(res);
});


app.listen(port, () => {
    console.info(`Server is listening on port ${port}.`);

});
