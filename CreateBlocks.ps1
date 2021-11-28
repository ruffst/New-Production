$BlockIds = @(

  'LargeBlockCockpitSeat'
  'SmallBlockCockpit'
  'DBSmallBlockFighterCockpit'
  'SmallBlockCockpitIndustrial'
  'LargeBlockCockpitIndustrial'
  'LargeBlockCockpit'
  'CockpitOpen'
  'OpenCockpitLarge'
  'OpenCockpitSmall'
  'RoverCockpit'
  'BuggyCockpit'
  'PassengerSeatLarge'
  'PassengerSeatSmall'

);
$Builder = "Cockpit"
$Freigeschaltet = "Meilenstein_Controls"

$TextBlock = '
        <ResearchBlock xsi:type="ResearchBlock">                                    <!--XXXXX  zzzzz-->
          <Id Type="MyObjectBuilder_yyyyy" Subtype="XXXXX" />
          <UnlockedByGroups>
            <GroupSubtype>zzzzz</GroupSubtype>
          </UnlockedByGroups>
        </ResearchBlock>'

foreach ($Block in $BlockIds)
{
$temp = $TextBlock -replace "XXXXX", $Block
$temp = $temp -replace "yyyyy", $Builder
$temp = $temp -replace "zzzzz", $Freigeschaltet
Write-Host $temp

}
