# WinBaramMacro

Login Macro

10/21 Github 처음 커밋완료.
 1. Git ignore 사용법 숙지 및 사용
 2. 

10/22 
1. stringParser Judge 부분 개선 진행 예정.
 - sendkey할때 (,),[,], 등 해당 문자일 경우 안됨
 - 특수키 추가 예정 ( key down up 등.. )

2. Command 수행하는 부분 시간에 따라 반복 진행할 수 있는 부분 추가 예정.
 - Time간격, 반복진행 시작,멈춤 키 추가할 예정

3. Json Save or Load할때 데이터 없을경우 처리부분 안정화 예정.

4. Refresh 부분 업데이트 예정
 - 현재는 Process만 켜져있으면 로그인으로 인식
  a. Process 존재하는지 확인.
  b. ID부분 비교하여 켜져있는지 확인.
  c. Reconnet Leave 창 떠있는지 확인.
  -> 위 순서대로 로그인 확인 예정
  + b, c에 해당될 경우 순서대로 진행하도록 하는 기능까지 구현 예정.
  
