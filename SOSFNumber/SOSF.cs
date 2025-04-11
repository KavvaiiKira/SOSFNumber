namespace SOSFNumber
{
    public class SOSF
    {
        private readonly string _resultFilePath;
        private readonly int _magicSOSFNumber = 6174;

        public SOSF()
        {
            _resultFilePath = Path.Combine(Environment.CurrentDirectory, "result.txt");

            if (!File.Exists(_resultFilePath))
            {
                var file = File.Create(_resultFilePath);
                file.Close();
            }
        }

        public void DoSOSF()
        {
            var number = 1000;

            while (number != 10000)
            {
                File.AppendAllText(_resultFilePath, $"Current number: {number}\n");

                SOSFSum(number);

                number++;
            }
        }

        private void SOSFSum(int number)
        {
            var sum = 0;
            var checkNum = number;

            while (sum != _magicSOSFNumber)
            {
                var firstS = GetOrderedSOSFNumber(checkNum, Order.DESC);
                var secondS = GetOrderedSOSFNumber(checkNum, Order.ASC);

                checkNum = firstS - secondS;

                File.AppendAllText(_resultFilePath, $"\t{firstS} - {secondS} = {checkNum}\n");

                if (checkNum == 0)
                {
                    File.AppendAllText(_resultFilePath, "\tskip...\n");
                    return;
                }

                sum = checkNum;
            }

            if (sum == _magicSOSFNumber)
            {
                File.AppendAllText(_resultFilePath, $"\tCorrect for {number}!\n");
            }
        }

        private int GetOrderedSOSFNumber(int number, Order order)
        {
            var strNum = number.ToString();

            switch (order)
            {
                case Order.ASC:
                    {
                        var lowerNumStr = string.Join("", strNum.OrderBy(c => c));

                        while (lowerNumStr.Length < 4)
                        {
                            lowerNumStr = "0" + lowerNumStr;
                        }

                        return int.Parse(lowerNumStr);
                    }
                case Order.DESC:
                    {
                        var biggerNumStr = string.Join("", strNum.OrderByDescending(c => c));

                        while (biggerNumStr.Length < 4)
                        {
                            biggerNumStr += "0";
                        }

                        return int.Parse(biggerNumStr);
                    }
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
