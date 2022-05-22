# Practice_Unity
Unity Engine Project

## 서바이벌 게임
<img src="https://user-images.githubusercontent.com/86781939/169697515-5e0ed0e3-e5bd-4206-87cf-99b3e492944a.png"  width="1000" height="600" >


## # 주요 기능

### **1. 플레이어 세팅**
<img src="https://user-images.githubusercontent.com/86781939/169697455-908d53e6-3f5b-4a95-8ba2-0f838d56f164.png"  width="1000" height="600" >

  - 플레이어 이동 (WASD로 이동, Shift로 달리기)
  - 점프 (스페이스바)
  - 3인칭 카메라 뷰 회전
  - 이동, 달리기 애니메이션 연결


### **2. 몬스터 세팅**
<img src="https://user-images.githubusercontent.com/86781939/169697494-6e6fc981-be8a-4c9a-902a-ea6a95e79048.PNG"  width="1000" height="600" >

  - NavMeshAgent 이용한 내비게이션
  - 플레이어를 따라감

  ```cs
  nvAgent.destination = playerTransform.position;
  ```

  - 이동 애니메이션 연결

  
### **3. 승리, 패배 조건**
<img src="https://user-images.githubusercontent.com/86781939/169697736-64c52722-6d7f-45c4-b73b-39bf7e60020f.PNG"  width="1000" height="600" >

  - 타이머: 화면에 남은 시간 출력

  ```cs
  time -= Time.deltaTime;
  timeText.text = Mathf.Ceil(time).ToString();
  ```

  - 설정된 시간 동안 생존 시 승리
  - 설정된 시간 내에 몬스터와 충돌 시 패배

  ```cs
  private void OnTriggerStay(Collider other)
  ```

  - 승리, 패배 이벤트 호출 (카메라 이동, 게임 종료)

  ```cs
  timeText.text = "You Win!";
  Time.timeScale = 0;
  ```