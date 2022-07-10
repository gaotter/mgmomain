const express = require('express');
const cors = require('cors');
const environment = process.env.environment;

const publicweb = environment === 'prod' ? './' : './dist';
const app = express();

app.use(express.static(publicweb));
console.log(`serving cors`);
app.get('*', (req, res) => {
  res.sendFile(`index.html`, { root: publicweb });
});
app.use(cors());

const port = process.env.PORT;
app.listen(port, () => console.log(`API running on localhost:${port}`));
