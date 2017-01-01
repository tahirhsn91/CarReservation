/**
 * Created by tahir.hassan on 12/23/2015.
 */

String.prototype.toCapitalizeCase = function () {
    return this.charAt(0).toUpperCase() + this.slice(1);
};

String.prototype.toCamelCase = function () {
    return this.charAt(0).toLowerCase() + this.slice(1);
};

String.prototype.slugify = function () {
    return this.trim().replace(/\s+/g, '-');
};

String.prototype.toCustomLocalDate = function () {
    var date = new Date(this);
    var day = date.getDate();
    var month = date.getMonth() + 1;
    var year = date.getFullYear();
    return month + '/' + day + '/' + year;
};

String.prototype.toBoolean = function () {
    if (this && this.toLowerCase() === 'true') {
        return true;
    }
    else {
        return false;
    }
};

String.prototype.parseDate = function () {
    var monthArray = {'Jan':0, 'Feb':1, 'Mar':2, 'Apr':3, 'May':4, 'Jun':5, 'Jul':6, 'Aug':7, 'Sep':8, 'Oct':9, 'Nov':10, 'Dec':11};
    var dateArray = this.split('-');
    return new Date(dateArray[2], monthArray[dateArray[1]], dateArray[0]);
};