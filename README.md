# WinBaramMacro

Login Macro

10/21 Github 처음 커밋완료.
 1. Git ignore 사용법 숙지 및 사용
 2. 

10/22 
1. stringParser Judge 부분 개선 진행 예정.  - 보류
 - sendkey할때 (,),[,], 등 해당 문자일 경우 안됨
 - 특수키 추가 예정 ( key down up 등.. )

2. Command 수행하는 부분 시간에 따라 반복 진행할 수 있는 부분 추가 예정. - 보류
 - Time간격, 반복진행 시작,멈춤 키 추가할 예정

3. Json Save or Load할때 데이터 없을경우 처리부분 안정화 예정. 
 - Command부분 수정. - 10/22 완료
 - ID 부분 Group 부분 미입력시 0으로 입력되도록 수정 - 해당부분 Cross Error 해결 필요.

4. Refresh 부분 업데이트 예정 - 보류
 - 현재는 Process만 켜져있으면 로그인으로 인식
  a. Process 존재하는지 확인.
  b. ID부분 비교하여 켜져있는지 확인.
  c. Reconnet Leave 창 떠있는지 확인.
  -> 위 순서대로 로그인 확인 예정
  + b, c에 해당될 경우 순서대로 진행하도록 하는 기능까지 구현 예정.
  
5. 명령어 (이전 명령어 수행한 아이디가 같을경우 Delay 줄것임. 10/22 완

6. 토로라비 고구려 대기중 -> 부여 이동시 문제 발생  - 10/22 완
 - 부여일경우 귀환 전 비영사천문 추가.

10/23
+ 로그인 이미지 crop 할경우 버그 수정
 : 생성자 static 으로 재설정하여 List Size Add 되도록 수정.
+ 토로라비 이동 개선
 : sendkey {enter}로 대체

1. Json Save or Load할때 데이터 없을경우 처리부분 안정화 예정. 
 - ID 부분 Group 부분 미입력시 0으로 입력되도록 수정 - 해당부분 Cross Error 처리.
 - Register에 마지막에 호출된 파일경로 저장하여 이후에 프로그램 실행시 해당경로로 불러와지도록 수정.
 - 현재 오픈된 파일 UI구현

2. Refresh 부분 업데이트 예정
 - 현재는 Process만 켜져있으면 로그인으로 인식
  a. Process 존재하는지 확인.
  b. ID부분 비교하여 켜져있는지 확인.
  c. Reconnet Leave 창 떠있는지 확인.
  -> 위 순서대로 로그인 확인 예정
  + b, c에 해당될 경우 순서대로 진행하도록 하는 기능까지 구현 예정.
