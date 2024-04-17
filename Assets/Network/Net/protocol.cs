using System;

namespace VirusWarGameServer
{
	public enum PROTOCOL : short
	{
		BEGIN = 0,
        ENTER_GAME_ROOM,

		// 클라이언트의 이동 요청.
		PLAYER_MOVING,

        // 게임 종료.
        GAME_OVER = 10,
		//메시지 전송
		CHAT_MSG,
        //캐릭터 나감
        PLAYER_EXIT,
        //플레이어 이름 요청
        PLAYER_NAME,

        //총 발사
        PLAYER_SHOOT,

        //플레이어 체력 동기화
        PLAYER_HEALTH,

        //몬스터의 타겟
        ENEMY_TARGET,
        //몬스터가 때리는걸 클라이언트에서 보낸다.
        ENEMY_ATTACK,

        INV_SYNCHRONIZATION,

        END
    }
}
