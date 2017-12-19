using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIC
{
    enum cardType
    {
        Ethernet,
        tokenRing
    }

    class NICCard
    {
        string _Manufactor;
        string _MACAddress;
        cardType _type;

        
        static NICCard _NIC;

        static NICCard()
        {
            _NIC = new NICCard("","",cardType.Ethernet);
        }

        private NICCard(string Manufactor,string MACAddress,cardType type)
        {
            _MACAddress = MACAddress;
            _Manufactor = Manufactor;
            _type = type;
        }

        public static NICCard getNICCard(string Manufactor, string MACAddress, cardType type)
        {
            _NIC._MACAddress = MACAddress;
            _NIC._Manufactor = Manufactor;
            _NIC._type = type;
            return _NIC;
        }
    }
}
