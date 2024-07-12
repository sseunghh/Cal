using System;

namespace Calculator_Pro
{
    public class Remove
    {
        // 텍스트에서 마지막 요소를 지우는 메서드
        public string RemoveLastElement(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }

            // 공백으로 끝나는 경우(예: "6 + ")
            if (text.EndsWith(" "))
            {
                // 연산자와 공백을 함께 제거
                return text.Substring(0, text.LastIndexOf(' ')).TrimEnd();
            }

            // 숫자나 연산자 하나를 지우기
            return text.Substring(0, text.Length - 1);
        }

        // 특정 조건에 따라 텍스트를 지우는 메서드 (예: "6 + 3 =")
        public string RemoveAfterEquals(string text)
        {
            if (string.IsNullOrEmpty(text) || !text.Contains("="))
            {
                return RemoveLastElement(text);
            }

            // "=" 다음의 내용을 지우기
            int equalsIndex = text.IndexOf("=");
            return text.Substring(0, equalsIndex);
        }
    }
}