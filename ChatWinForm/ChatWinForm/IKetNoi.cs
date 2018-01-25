using System;
namespace ChatWinForm
{
    public interface IKetNoi
    {
        void Connect();
        string KetQuaDem();
        event EventHandler OnGraphChanged;
        void Send(string cauChat);
    }
}
