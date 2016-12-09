module.exports = {
  dist: {
    files:[
      {
        src: 'app/index.html',
        dest: '../API/CarReservation.API/index.html'
      },
      {
        cwd: 'app/fonts',
        src: '**',
        dest: '../API/CarReservation.API/fonts/',
        expand: true
      },
      {
        cwd: 'app/images',
        src: '**/*.*',
        dest: '../API/CarReservation.API/images/',
        expand: true
      }
    ]
  }
}
