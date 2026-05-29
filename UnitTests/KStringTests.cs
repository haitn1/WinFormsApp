
using System.Drawing;
using WinApp.Common;
namespace UnitTests
{
    [TestFixture]
    public class KStringTests
    {
        private KString _kString = null!;

        /// <summary>
        /// Verifies that the constructor initializes an empty string correctly.
        /// </summary>
        [Test]
        public void Constructor_Default_InitializesEmpty()
        {
            _kString = new KString();
            Assert.That(_kString.Text, Is.EqualTo(""));
            Assert.That(_kString.Klen, Is.EqualTo(0));
            Assert.That(_kString.Blen, Is.EqualTo(0));
        }

        /// <summary>
        /// Verifies that the constructor initializes with the provided text.
        /// </summary>
        [Test]
        public void Constructor_WithText_InitializesCorrectly()
        {
            _kString = new KString("abc");
            Assert.That(_kString.Text, Is.EqualTo("abc"));
            Assert.That(_kString.Klen, Is.EqualTo(3));
            Assert.That(_kString.Blen, Is.EqualTo(3));
        }

        /// <summary>
        /// Verifies that the constructor handles null input gracefully.
        /// </summary>
        [Test]
        public void Constructor_NullText_InitializesEmpty()
        {
            _kString = new KString(null!);
            Assert.That(_kString.Text, Is.EqualTo(""));
            Assert.That(_kString.Klen, Is.EqualTo(0));
            Assert.That(_kString.Blen, Is.EqualTo(0));
        }

        /// <summary>
        /// Verifies that the Text property sets and gets text correctly.
        /// </summary>
        [Test]
        public void Text_SetAndGet_WorksCorrectly()
        {
            _kString = new KString();
            _kString.Text = "def";
            Assert.That(_kString.Text, Is.EqualTo("def"));
            Assert.That(_kString.Klen, Is.EqualTo(3));
            Assert.That(_kString.Blen, Is.EqualTo(3));
        }

        /// <summary>
        /// Verifies that the Text property handles null correctly.
        /// </summary>
        [Test]
        public void Text_SetNull_SetsToEmpty()
        {
            _kString = new KString("abc");
            _kString.Text = null!;
            Assert.That(_kString.Text, Is.EqualTo(""));
            Assert.That(_kString.Klen, Is.EqualTo(0));
            Assert.That(_kString.Blen, Is.EqualTo(0));
        }

        /// <summary>
        /// Verifies that Klen returns the correct character length.
        /// </summary>
        [Test]
        public void Klen_MixedString_ReturnsCorrectCharLength()
        {
            _kString = new KString("aあb");
            Assert.That(_kString.Klen, Is.EqualTo(3));
        }

        /// <summary>
        /// Verifies that Blen returns the correct byte length.
        /// </summary>
        [Test]
        public void Blen_MixedString_ReturnsCorrectByteLength()
        {
            _kString = new KString("aあb");
            Assert.That(_kString.Blen, Is.EqualTo(4));
        }

        /// <summary>
        /// Verifies that GetBtyp returns the correct byte type.
        /// </summary>
        [Test]
        public void GetBtyp_ValidIndex_ReturnsCorrectType()
        {
            _kString = new KString("aあb");
            Assert.That(_kString.GetBtyp(1), Is.EqualTo(1)); // 'a'
            Assert.That(_kString.GetBtyp(2), Is.EqualTo(2)); // 'あ' lead
            Assert.That(_kString.GetBtyp(3), Is.EqualTo(3)); // 'あ' trail
            Assert.That(_kString.GetBtyp(4), Is.EqualTo(1)); // 'b'
        }

        /// <summary>
        /// Verifies that GetBtyp returns 0 for out-of-bounds indices.
        /// </summary>
        [Test]
        public void GetBtyp_InvalidIndex_ReturnsZero()
        {
            _kString = new KString("aあb");
            Assert.That(_kString.GetBtyp(0), Is.EqualTo(0));
            Assert.That(_kString.GetBtyp(5), Is.EqualTo(0));
        }

        /// <summary>
        /// Verifies that GetKtyp returns the correct character type.
        /// </summary>
        [Test]
        public void GetKtyp_ValidIndex_ReturnsCorrectType()
        {
            _kString = new KString("aあb");
            Assert.That(_kString.GetKtyp(1), Is.EqualTo(1)); // 'a'
            Assert.That(_kString.GetKtyp(2), Is.EqualTo(2)); // 'あ'
            Assert.That(_kString.GetKtyp(3), Is.EqualTo(1)); // 'b'
        }

        /// <summary>
        /// Verifies that GetKtyp returns 0 for out-of-bounds indices.
        /// </summary>
        [Test]
        public void GetKtyp_InvalidIndex_ReturnsZero()
        {
            _kString = new KString("aあb");
            Assert.That(_kString.GetKtyp(0), Is.EqualTo(0));
            Assert.That(_kString.GetKtyp(4), Is.EqualTo(0));
        }

        /// <summary>
        /// Verifies that GetKadr returns the correct byte address.
        /// </summary>
        [Test]
        public void GetKadr_ValidIndex_ReturnsCorrectAddress()
        {
            _kString = new KString("aあb");
            Assert.That(_kString.GetKadr(1), Is.EqualTo(1));
            Assert.That(_kString.GetKadr(2), Is.EqualTo(2));
            Assert.That(_kString.GetKadr(3), Is.EqualTo(4));
        }

        /// <summary>
        /// Verifies that GetKadr returns 0 for out-of-bounds indices.
        /// </summary>
        [Test]
        public void GetKadr_InvalidIndex_ReturnsZero()
        {
            _kString = new KString("aあb");
            Assert.That(_kString.GetKadr(0), Is.EqualTo(0));
            Assert.That(_kString.GetKadr(4), Is.EqualTo(0));
        }

        /// <summary>
        /// Verifies that GetBmid returns the correct substring by byte.
        /// </summary>
        [Test]
        public void GetBmid_ValidIndex_ReturnsCorrectSubstring()
        {
            _kString = new KString("aあbいc"); // Blen = 8
            Assert.That(_kString.GetBmid(2, 3), Is.EqualTo("あb"));
            Assert.That(_kString.GetBmid(1, 8), Is.EqualTo("aあbいc"));
            Assert.That(_kString.GetBmid(8, 1), Is.EqualTo(""));
        }

        /// <summary>
        /// Verifies that GetBmid handles invalid arguments gracefully.
        /// </summary>
        [Test]
        public void GetBmid_InvalidArgs_ReturnsEmpty()
        {
            _kString = new KString("aあbいc");
            Assert.That(_kString.GetBmid(9, 1), Is.EqualTo(""));
            Assert.That(_kString.GetBmid(1, 0), Is.EqualTo(""));
            Assert.That(_kString.GetBmid(0, 1), Is.EqualTo("a")); // start becomes 1
        }

        /// <summary>
        /// Verifies that GetBlef returns the correct left substring by byte.
        /// </summary>
        [Test]
        public void GetBlef_ValidLength_ReturnsCorrectSubstring()
        {
            _kString = new KString("aあbいc");
            Assert.That(_kString.GetBlef(3), Is.EqualTo("aあ"));
            Assert.That(_kString.GetBlef(8), Is.EqualTo("aあbいc"));
            Assert.That(_kString.GetBlef(0), Is.EqualTo(""));
        }

        /// <summary>
        /// Verifies that GetBrig returns the correct right substring by byte.
        /// </summary>
        [Test]
        public void GetBrig_ValidLength_ReturnsCorrectSubstring()
        {
            _kString = new KString("aあbいc");
            Assert.That(_kString.GetBrig(3), Is.EqualTo("いc"));
            Assert.That(_kString.GetBrig(8), Is.EqualTo("aあbいc"));
            Assert.That(_kString.GetBrig(0), Is.EqualTo(""));
        }

        /// <summary>
        /// Verifies that GetBaft returns the correct substring after a byte index.
        /// </summary>
        [Test]
        public void GetBaft_ValidIndex_ReturnsCorrectSubstring()
        {
            _kString = new KString("aあbいc");
            Assert.That(_kString.GetBaft(4), Is.EqualTo("bいc"));
            Assert.That(_kString.GetBaft(9), Is.EqualTo(""));
        }

        /// <summary>
        /// Verifies that GetKmid returns the correct substring by character.
        /// </summary>
        [Test]
        public void GetKmid_ValidIndex_ReturnsCorrectSubstring()
        {
            _kString = new KString("aあbいc"); // Klen = 5
            Assert.That(_kString.GetKmid(2, 3), Is.EqualTo("あbい"));
            Assert.That(_kString.GetKmid(1, 5), Is.EqualTo("aあbいc"));
            Assert.That(_kString.GetKmid(5, 1), Is.EqualTo("c"));
        }

        /// <summary>
        /// Verifies that GetKmid handles invalid arguments gracefully.
        /// </summary>
        [Test]
        public void GetKmid_InvalidArgs_ReturnsEmpty()
        {
            _kString = new KString("aあbいc");
            Assert.That(_kString.GetKmid(6, 1), Is.EqualTo(""));
            Assert.That(_kString.GetKmid(1, 0), Is.EqualTo(""));
            Assert.That(_kString.GetKmid(0, 2), Is.EqualTo("aあ")); // start becomes 1
        }

        /// <summary>
        /// Verifies that GetKlef returns the correct left substring by character.
        /// </summary>
        [Test]
        public void GetKlef_ValidLength_ReturnsCorrectSubstring()
        {
            _kString = new KString("aあbいc");
            Assert.That(_kString.GetKlef(3), Is.EqualTo("aあb"));
            Assert.That(_kString.GetKlef(5), Is.EqualTo("aあbいc"));
            Assert.That(_kString.GetKlef(0), Is.EqualTo(""));
        }

        /// <summary>
        /// Verifies that GetKrig returns the correct right substring by character.
        /// </summary>
        [Test]
        public void GetKrig_ValidLength_ReturnsCorrectSubstring()
        {
            _kString = new KString("aあbいc");
            Assert.That(_kString.GetKrig(3), Is.EqualTo("bいc"));
            Assert.That(_kString.GetKrig(5), Is.EqualTo("aあbいc"));
            Assert.That(_kString.GetKrig(0), Is.EqualTo(""));
        }

        /// <summary>
        /// Verifies that GetKaft returns the correct substring after a character index.
        /// </summary>
        [Test]
        public void GetKaft_ValidIndex_ReturnsCorrectSubstring()
        {
            _kString = new KString("aあbいc");
            Assert.That(_kString.GetKaft(3), Is.EqualTo("bいc"));
            Assert.That(_kString.GetKaft(6), Is.EqualTo(""));
        }

        /// <summary>
        /// Verifies that GetInt extracts an integer correctly.
        /// </summary>
        [Test]
        public void GetInt_ValidString_ReturnsCorrectInt()
        {
            _kString = new KString("abc 123 def 456");
            Assert.That(_kString.GetInt(), Is.EqualTo(123));
            Assert.That(_kString.GetInt(), Is.EqualTo(456));
        }

        /// <summary>
        /// Verifies that GetInt returns 0 when no integer is found.
        /// </summary>
        [Test]
        public void GetInt_NoInt_ReturnsZero()
        {
            _kString = new KString("abc def");
            Assert.That(_kString.GetInt(), Is.EqualTo(0));
        }

        /// <summary>
        /// Verifies that GetHex extracts a hexadecimal integer correctly.
        /// </summary>
        [Test]
        public void GetHex_ValidString_ReturnsCorrectHex()
        {
            _kString = new KString("abc $FF def $A0");
            Assert.That(_kString.GetHex(), Is.EqualTo(255));
            Assert.That(_kString.GetHex(), Is.EqualTo(160));
        }

        /// <summary>
        /// Verifies that GetDbl extracts a double correctly.
        /// </summary>
        [Test]
        public void GetDbl_ValidString_ReturnsCorrectDouble()
        {
            _kString = new KString("abc 123.45 def 6.78");
            Assert.That(_kString.GetDbl(), Is.EqualTo(123.45));
            Assert.That(_kString.GetDbl(), Is.EqualTo(6.78));
        }

        /// <summary>
        /// Verifies that GetStr extracts a quoted string correctly.
        /// </summary>
        [Test]
        public void GetStr_ValidString_ReturnsCorrectString()
        {
            _kString = new KString(" 'hello world' " + " \"escaped\" ");
            Assert.That(_kString.GetStr(), Is.EqualTo("hello world"));
            Assert.That(_kString.GetStr(), Is.EqualTo("escaped"));
            _kString = new KString("hello world1");
            Assert.That(_kString.GetStr(), Is.EqualTo(string.Empty));
        }

        /// <summary>
        /// Verifies that GetStr handles escaped quotes correctly.
        /// </summary>
        [Test]
        public void GetStr_EscapedQuotes_ReturnsCorrectString()
        {
            _kString = new KString("'rock \'n\' roll'");
            Assert.That(_kString.GetStr(), Is.EqualTo("n"));
        }

        /// <summary>
        /// Verifies that Get128 extracts a 128-bit integer correctly.
        /// </summary>
        [Test]
        public void Get128_ValidString_ReturnsCorrectInt()
        {
            var extStr = new ExtString();
            string encoded = extStr.To128(12345);
            _kString = new KString("abc " + encoded);
            Assert.That(_kString.Get128(), Is.EqualTo(12345));
        }

        /// <summary>
        /// Verifies that Get128D extracts a 128-bit double correctly.
        /// </summary>
        [Test]
        public void Get128D_ValidString_ReturnsCorrectDouble()
        {
            var extStr = new ExtString();
            string encoded = extStr.To128D(123.45);
            _kString = new KString("abc " + encoded);
            Assert.That(_kString.Get128D(), Is.EqualTo(123.45).Within(0.0000000001));
        }


        /// <summary>
        /// Verifies that GetColor extracts a color correctly (BGR format).
        /// </summary>
        [Test]
        public void GetColor_ValidString_ReturnsCorrectColor()
        {
            _kString = new KString("$FF0000"); // Blue in BGR
            Assert.That(_kString.GetColor(), Is.EqualTo(Color.FromArgb(0, 0, 255)));

            _kString = new KString("$00FF00"); // Green in BGR
            Assert.That(_kString.GetColor(), Is.EqualTo(Color.FromArgb(0, 255, 0)));

            _kString = new KString("$0000FF"); // Red in BGR
            Assert.That(_kString.GetColor(), Is.EqualTo(Color.FromArgb(255, 0, 0)));
        }
    }
}