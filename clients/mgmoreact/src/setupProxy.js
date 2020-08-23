const { createProxyMiddleware } = require('http-proxy-middleware');
module.exports = function(app) {
  app.use(
    '/api',
    createProxyMiddleware({
      target: 'https://localhost:44361',
      secure: false,
      changeOrigin: true,
      pathRewrite: {
        "^/api": ""
      }
    })
  );
};