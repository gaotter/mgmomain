const express = require('express');

const publicweb = './' || './dist';
const app = express();

app.use(express.static(publicweb));
console.log(`serving ${process.env.PUBLICWEB}`);
app.get('*', (req, res) => {
  res.sendFile(`index.html`, { root: publicweb });
});

const port = '8080' || '3000';
app.listen(port, () => console.log(`API running on localhost:${port}`));
