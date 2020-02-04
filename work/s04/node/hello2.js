/**
 * A simple test program.
 *
 * @author Rami Alnaser
 */
"use strict";
    function main() {
    let a = 1;
    let b;
    let range = "";


    for (let i=0; i < 9; i++) {
       range += i + ", ";
    }

    console.info("Hello World");
    console.info(range.substring(0, range.length - 2));
    console.info(a, b);

    }
    main();
  
