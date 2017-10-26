/**
 * Created by authg on 2017/10/27.
 */

var scaffold = require('gulp-ng-scaffold');
var gulp = require('gulp');
var gutil = require('gulp-util');
var fs = require('fs');
var SwaggerParser = require('swagger-parser');

gulp.task('scaffold', function () {
    var opts = {
        debug: false,
        appName: 'pulse',
        resourceOutput: './Modules/resources',
        testsOutput: './Modules/resources/tests',
        serverBase: 'http://pulse.local/',
        resourceConfigName: 'resourceConfig'
    };

    return gulp.src('./api/*.json')
        .pipe(scaffold(opts))
        .pipe(gulp.dest('./Modules/resources'))
        .on('error', gutil.log);
});

gulp.task('fetch', function (callback) {
    SwaggerParser.validate('http://pulse.local:80/swagger/docs/v2')
        .then(function (api) {
            fs.mkdir('./api/', function (error) {
                if (error) {
                    //sadness
                }
                var name = './api/' + api.info.title.replace('/', '') + '.json';
                fs.writeFileSync(name, JSON.stringify(api), 'utf-8');
                callback();
            });
        })
        .catch(function (err) {
            console.error(err);
        });
});