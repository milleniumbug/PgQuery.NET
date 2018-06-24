#!/bin/bash
cd native_lib
make
mkdir out_o
gcc -shared out_o/*.o -o libpg_query.so
cd ..

