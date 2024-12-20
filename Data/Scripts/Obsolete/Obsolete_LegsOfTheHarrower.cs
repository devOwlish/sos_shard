using System;
using Server;

namespace Server.Items
{
	public class LegsOfTheHarrower : BoneLegs
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int LabelNumber{ get{ return 1061095; } } // Legs Of The Harrower

		public override int BasePoisonResistance{ get{ return 21; } }

		[Constructable]
		public LegsOfTheHarrower()
		{
			Name = "Leggings of the Harrower";
			Hue = 0x4F6;
			Attributes.RegenHits = 5;
			Attributes.RegenStam = 5;
			Attributes.WeaponDamage = 21;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public LegsOfTheHarrower( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 );
		}
		
		private void Cleanup( object state ){ Item item = new Artifact_LegsOfTheHarrower(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

			int version = reader.ReadInt();

			if ( version < 1 )
			{
				if ( Hue == 0x55A )
					Hue = 0x4F6;

				PoisonBonus = 0;
			}
		}
	}
}