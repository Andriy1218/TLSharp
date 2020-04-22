using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TeleSharp.TL;
using TeleSharp.TL.Account;
using TeleSharp.TL.Contacts;
using TeleSharp.TL.Messages;
using TeleSharp.TL.Upload;

namespace TLSharp.Core
{
    public interface ITelegramClient : IDisposable
    {
        Session Session { get; }
        Task ConnectAsync(bool reconnect = false, CancellationToken token = default(CancellationToken));
        bool IsUserAuthorized();
        Task<bool> IsPhoneRegisteredAsync(string phoneNumber, CancellationToken token = default(CancellationToken));
        Task<string> SendCodeRequestAsync(string phoneNumber, CancellationToken token = default(CancellationToken));
        Task<TLUser> MakeAuthAsync(string phoneNumber, string phoneCodeHash, string code, CancellationToken token = default(CancellationToken));
        Task<TLPassword> GetPasswordSetting(CancellationToken token = default(CancellationToken));
        Task<TLUser> MakeAuthWithPasswordAsync(TLPassword password, string password_str, CancellationToken token = default(CancellationToken));
        Task<TLUser> SignUpAsync(string phoneNumber, string phoneCodeHash, string firstName, string lastName, CancellationToken token = default(CancellationToken));
        Task<T> SendRequestAsync<T>(TLMethod methodToExecute, CancellationToken token = default(CancellationToken));
        Task<TLUser> UpdateUsernameAsync(string username, CancellationToken token = default(CancellationToken));
        Task<bool> CheckUsernameAsync(string username, CancellationToken token = default(CancellationToken));
        Task<TLImportedContacts> ImportContactsAsync(IReadOnlyList<TLInputPhoneContact> contacts, CancellationToken token = default(CancellationToken));
        Task<bool> DeleteContactsAsync(IReadOnlyList<TLAbsInputUser> users, CancellationToken token = default(CancellationToken));
        Task<TLAbsUpdates> DeleteContactAsync(TLAbsInputUser user, CancellationToken token = default(CancellationToken));
        Task<TLContacts> GetContactsAsync(CancellationToken token = default(CancellationToken));
        Task<TLAbsUpdates> SendMessageAsync(TLAbsInputPeer peer, string message, CancellationToken token = default(CancellationToken));
        Task<Boolean> SendTypingAsync(TLAbsInputPeer peer, CancellationToken token = default(CancellationToken));
        Task<TLAbsDialogs> GetUserDialogsAsync(int offsetDate = 0, int offsetId = 0, TLAbsInputPeer offsetPeer = null, int limit = 100, CancellationToken token = default(CancellationToken));
        Task<TLAbsUpdates> SendUploadedPhoto(TLAbsInputPeer peer, TLAbsInputFile file, string caption, CancellationToken token = default(CancellationToken));
        Task<TLAbsUpdates> SendUploadedDocument(TLAbsInputPeer peer, TLAbsInputFile file, string caption, string mimeType, TLVector<TLAbsDocumentAttribute> attributes, CancellationToken token = default(CancellationToken));
        Task<TLFile> GetFile(TLAbsInputFileLocation location, int filePartSize, int offset = 0, CancellationToken token = default(CancellationToken));
        Task SendPingAsync(CancellationToken token = default(CancellationToken));
        Task<TLAbsMessages> GetHistoryAsync(TLAbsInputPeer peer, int offsetId = 0, int offsetDate = 0, int addOffset = 0, int limit = 100, int maxId = 0, int minId = 0, CancellationToken token = default(CancellationToken));
        Task<TLFound> SearchUserAsync(string q, int limit = 10, CancellationToken token = default(CancellationToken));
        bool IsConnected { get; }
    }
}
