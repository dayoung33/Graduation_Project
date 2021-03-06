# <3cm Hunter>

# “어느 날 몸이 3cm로 작아졌다, 끝까지 살아남아 동생을 구하자!”


# 게임 개요

장르

액션 어드벤처
스토리를 기반으로 진행되는 게임으로 퀘스트를 통해 길을 안내하고 이동을 통제하면서 스토리 진행함

플랫폼

PC 

게임 목표

1. 여러가지 위험 요소들을 지나서 동생을 구해야 함
2. 동생과 함께 빛의 기둥에 들어가면 엔딩을 볼 수 있음

개발엔진

Unity 

게임 특징
1. 10분의 1로 줄어든 플레이어
2. 실생활에서 하찮은 존재가 위협적으로 나타남 (ex. 거미, 비, 로봇청소기 등)

# 게임 컨셉

게임 스토리
시놉시스
어느 날 모든 사람들이 동시에 3cm로 줄어들고, 각자 고유의 초능력이 생겼다. 
주인공은 고유 능력인 방어막 생성과 염력을 이용해 이 세상에 살아남아 동생을 구해야 한다. 
동생을 구하러 집으로 돌아가는 길에는 나보다 커진 거미와 한 방울만 맞아도 치명적인 비가 내리는 공원을 지나야 하고, 집안 청소를 도와주던 로봇 청소기마저 생명의 위협을 느끼게 한다. 

주요 등장인물
1. 주인공 플레이어 – 초능력을 이용해 동생을 구해야 함
2. 동생 – 집안에서 알 수 없는 크기가 줄어들지 않은 사람이 나타나 햄스터 케이지 안에 갇혀 둠
3. 거미 – 플레이어가 가까이 오면 공격하고, 플레이어가 던진 물건을 맞으면 죽음
4. 로봇 청소기 – 집안을 랜덤하게 돌아다니며 청소를 함 
5. 새 – 빵을 먹다 플레이어가 가까이 오면 공격하고 플레이어가 물건을 던지면 일시적으로 도망감

# 게임 시스템

플레이어 조작


키보드	

- WASD	/ 플레이어 상하좌우 이동

- Space Bar	/ 플레이어 점프

- Shift	/ 달리기/걷기

- E	/ 방어막 발동

- M	/ 지도 꺼내기

- Tab	/ 지도 확대/축소


마우스

- Left Button Down	/ 주변 사물 염력으로 들어올리기

- Left Button Up	/ 염력으로 들어올린 물체 던지기

플레이어 능력

1. 염력	

- 염력은 일정거리 안의 물건을 던지거나 이동시킬 수 있음
많은 물건을 한 번에 옮길수록 들고 있을 수 있는 시간이 줄어듦
물건을 오래 들고 있을 수록 던지는 힘이 강해짐

2. 방어막

- 10초의 쿨 타임이 존재함
- 방어막을 켜고 있는 동안은 모든 방해 요소의 방해를 막을 수 있음

방해 요소

모든 방해 요소는 고유 능력인 방어막을 이용해 막을 수 있음

1. 비

- 공원 내에 비 내리는 영역에 파티클 시스템을 사용해 비를 표현하고, 영역 안에 플레이어가 들어올 시 플레이어 체력이 점점 감소함	

2. 거미, 새

- 플레이어가 일정 거리 안에 탐지 면 플레이어를 추격해 이동함, 공격 사정 거리 내에 플레이어가 들어오면 플레이어를 공격함 플레이어가 던진 물체에 맞으면 피격

3. 로봇 청소기

- 집 안을 무작위로 돌아다니면서 청소를 함, 플레이어는 소리를 듣고 가까이에 청소기가 다가오는 것을 감지할 수 있음, 플레이어와 청소기가 부딪힐 경우 플레이어에게 치명타


# 리소스 출처
모든 리소스는 무료로 제공된 리소스를 사용하였음

그래픽 리소스

1. 플레이어 
- 모델	 
https://assetstore.unity.com/packages/3d/characters/human-characters-free-sample-pack-181554
- 방어막	
https://assetstore.unity.com/packages/vfx/shaders/responsive-energy-shield-141118	
- 애니메이션	 
https://www.mixamo.com/#/?page=1&type=Motion%2CMotionPack	


2. 방해요소 리소스

- 거미	 
https://assetstore.unity.com/packages/3d/characters/animals/insects/animated-spider-22986
- 새	 
https://assetstore.unity.com/packages/3d/characters/animals/birds/living-birds-15649
- 비	 
https://assetstore.unity.com/packages/essentials/asset-packs/unity-particle-pack-5-x-73777	
-	로봇청소기	 
https://www.turbosquid.com/ko/3d-models/floor-carpet-model-1409270

3. 맵 리소스

-	튜토리얼 맵	 
https://assetstore.unity.com/packages/3d/environments/sci-fi/snaps-prototype-sci-fi-industrial-136759	
-	도시 건물 & 길
https://assetstore.unity.com/packages/tools/game-toolkits/citytools-88707	
-	집	 
https://assetstore.unity.com/packages/3d/environments/urban/furnished-cabin-71426	
-	나무	 
https://assetstore.unity.com/packages/3d/environments/fantasy/fantasy-forest-environment-free-demo-35361	
-	공원, 도시 거치물	 
https://assetstore.unity.com/packages/3d/props/city-props-pack-153581	
-	마트, 메인 스테이지 스카이 박스	 
https://assetstore.unity.com/packages/3d/environments/roadways/windridge-city-132222	
-	빵	 
https://assetstore.unity.com/packages/3d/props/food/croissants-pack-112263	
-	햄스터 케이지	 
https://assetstore.unity.com/packages/3d/props/hamstercage-110028	
-	돌	 
https://assetstore.unity.com/packages/3d/environments/landscapes/photoreal-stones-pack-demo-70005	


4. 기타 그래픽 리소스

-	빛의 기둥 파티클, 플레이어 체력 증가 Effect	 
https://assetstore.unity.com/packages/vfx/particles/particle-collection-skj-2016-free-samples-72399	
-	플레이어 UI	
https://assetstore.unity.com/packages/2d/gui/icons/free-ui-pack-170878	
- 로고 폰트	 
https://assetstore.unity.com/packages/2d/fonts/free-pixel-font-thaleah-140059	

사운드 리소스

1. 효과음	https://www.zapsplat.com/sound-effect-categories/
2. BGM	https://studio.youtube.com/channel/UCFDHBsEIxpSzgrM2uoG_IBQ/music


