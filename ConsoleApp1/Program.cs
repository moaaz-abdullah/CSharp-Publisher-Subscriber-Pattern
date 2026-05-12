using System.Threading.Channels;

namespace ConsoleApp1
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            YoutubeChannel youtubeChannel = new YoutubeChannel() { ChannelName = "Mo" };

            Subscriber subscriber1 = new Subscriber();
            Subscriber subscriber2 = new Subscriber();
            Subscriber subscriber3 = new Subscriber();

            subscriber1.Subscribe(youtubeChannel);
            subscriber2.Subscribe(youtubeChannel);
            subscriber3.Subscribe(youtubeChannel);

            youtubeChannel.videoUploaded -= subscriber2.Watch;

            Comments comment = new Comments();
            comment.AddComment(youtubeChannel);
            comment.Comment = "Wow";

            Notify notify = new Notify();
            notify.HandleEmail(youtubeChannel);

            youtubeChannel.UploadVideo("New Challenge", "Moaaz Abdullah");

            Console.ReadKey();
        }
    }

    public class VideoInfoEventArgs : EventArgs
    {
        public string Title { get; set; }

        public int Duration { get; set; }

        public string Author { get; set; }
    }

    class YoutubeChannel
    {
        public event EventHandler<VideoInfoEventArgs> videoUploaded;

        public string ChannelName { get; set; }

        public void UploadVideo(string title, string author)
        {
            Console.WriteLine($"Uploaded {title} video");
            videoUploaded?.Invoke(this, new VideoInfoEventArgs { Title = title, Duration = 23, Author = author });
        }
    }

    class Subscriber
    {

        public void Subscribe(YoutubeChannel channel)
        {
            channel.videoUploaded += Watch;
        }

        public void Watch(object sender, VideoInfoEventArgs e)
        {
            YoutubeChannel channel = (YoutubeChannel)sender;

            Console.WriteLine($"User is watching {e.Title} {e.Duration} Min Author {e.Author} Channel {channel.ChannelName}");
        }
    }

    class Comments
    {
        public string Comment { get; set; }

        public void AddComment(YoutubeChannel channel)
        {
            channel.videoUploaded += AddDefaultComment;
        }

        private void AddDefaultComment(object? sender, VideoInfoEventArgs e)
        {
            YoutubeChannel channel = sender as YoutubeChannel;

            Console.WriteLine($"{Comment} comment has been added on {channel.ChannelName} Channel ");
        }
    }


    class Notify
    {
        public void HandleEmail(YoutubeChannel channel)
        {
            channel.videoUploaded += SendEmails;
        }

        public void SendEmails(object? sender, VideoInfoEventArgs e)
        {
            YoutubeChannel channel = (YoutubeChannel)sender;

            Console.WriteLine($"Sending emails to other subscribers...\nDetails as follow:\nVideo Name: {e.Title}\nDuration: {e.Duration}\nAutor: {e.Author}\n{channel.ChannelName}Channel");
        }
    }

}