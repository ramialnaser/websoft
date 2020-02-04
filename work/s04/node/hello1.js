function main() {
    let a = 100;
    let b=0;
    let range = "";


    while(true){
      if(b===a){
        b += 1;
      }else {
        break;
      }
    }
    //for (let i=0; i < 9; i++) {
    //    range += i + ", ";
    //}

    console.info("Hello World");
    console.info(range.substring(0, range.length - 2));
    console.info(a, b);

    var curday = function(sp){
    today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth()+1;
    var yyyy = today.getFullYear();

    if(dd<10) dd='0'+dd;
    if(mm<10) mm='0'+mm;
    return (mm+sp+dd+sp+yyyy);
    };
    console.log(curday('/'));

}
main();
