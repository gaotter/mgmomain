const express = require('express');
const cors = require('cors');

const publicweb = './dist' || './dist';
const app = express();

app.use(express.static(publicweb));
console.log(`serving cors`);
app.get('*', (req, res) => {
  res.sendFile(`index.html`, { root: publicweb });
});
app.use(cors());

const port = '8080' || '3000';
app.listen(port, () => console.log(`API running on localhost:${port}`));
