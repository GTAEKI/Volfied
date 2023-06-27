/*
using System;

class Program
{
    static void Main(string[] args)
    {
        int[,] canvas = new int[8, 8]
        {
            {0, 0, 1, 0, 0, 1, 0, 0},
            {0, 0, 1, 0, 0, 1, 0, 0},
            {0, 0, 1, 0, 0, 1, 0, 0},
            {0, 0, 1, 1, 1, 1, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 2, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0}
        };

        FloodFill(canvas, 7, 7, 2);

        // 결과 출력
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Console.Write(canvas[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    static void FloodFill(int[,] canvas, int startX, int startY, int targetColor)
    {
        int originalColor = canvas[startX, startY];

        // 시작 위치가 타겟 컬러와 동일하거나 시작 위치가 캔버스 범위를 벗어나면 중지
        if (originalColor == targetColor || startX < 0 || startX >= canvas.GetLength(0) || startY < 0 || startY >= canvas.GetLength(1))
            return;

        Fill(canvas, startX, startY, targetColor, originalColor);
    }

    static void Fill(int[,] canvas, int x, int y, int targetColor, int originalColor)
    {
        // 현재 위치가 캔버스 범위를 벗어나거나 현재 위치의 색이 originalColor가 아니면 중지
        if (x < 0 || x >= canvas.GetLength(0) || y < 0 || y >= canvas.GetLength(1) || canvas[x, y] != originalColor)
            return;

        // 현재 위치의 색을 targetColor로 변경
        canvas[x, y] = targetColor;

        // 상하좌우로 재귀적으로 호출
        Fill(canvas, x + 1, y, targetColor, originalColor); // 오른쪽
        Fill(canvas, x - 1, y, targetColor, originalColor); // 왼쪽
        Fill(canvas, x, y + 1, targetColor, originalColor); // 위쪽
        Fill(canvas, x, y - 1, targetColor, originalColor); // 아래쪽
    }
}
*/