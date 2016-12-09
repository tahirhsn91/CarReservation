var proxySnippet = require('grunt-connect-proxy/lib/utils').proxyRequest;

module.exports = {
  options: {
    port: 7030,
    // Change this to '0.0.0.0' to access the server from outside.
    hostname: 'localhost',
    livereload: 35729
  },
  proxies: [
    // {
    //   context: '/api',
    //   host: '172.16.2.122',
    //   port: 1401
    // }

    {
      context: '/api',
      host: '35.164.206.165',
      port: 80
    }
  ],
  livereload: {
    options: {
      open: true,
      middleware: function (connect){
        return [
          connect().use(proxySnippet),
          connect.static('./app')
        ];
      }
    }
  }
};
