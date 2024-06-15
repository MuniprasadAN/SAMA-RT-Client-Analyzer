Imports Microsoft.VisualBasic

Imports System

Imports System.Windows.Forms

Imports System.Reflection

Imports System.Collections

Imports System.ComponentModel

Imports System.IO

Imports System.Runtime.Serialization.Formatters.Binary

Namespace CtrlCloneTst

#Region "ControlFactory"
Public Class ControlFactory

         

Public Shared Function CreateControl(ByVal ctrlName As String, ByVal partialName As String) As Control

            Try

                Dim ctrl As Control

                Select Case ctrlName
                     Case "LevelIndicator"

                        ctrl = New LevelIndicator()

                    Case "LineElbow"

                        ctrl = New LineElbow()

                    Case "Valve"

                        ctrl = New Valve()

                    Case "Circuit_Breaker"

                        ctrl = New Circuit_Breaker()

                    Case "ManualContactor"

                        ctrl = New ManualContactor()

                    Case "Distillation_Tower"

                        ctrl = New Distillation_Tower()

                    Case "Jacketed_Vessel"

                        ctrl = New Jacketed_Vessel()

                    Case "Reactor"

                        ctrl = New Reactor()

                    Case "Vessel"

                        ctrl = New Vessel()

                    Case "Admospheric_Tank"

                        ctrl = New Admospheric_Tank()



                     Case "Bin"

                        ctrl = New Bin()

                    Case "FloatingRoof_Tank"

                        ctrl = New FloatingRoof_Tank()

                    Case "Gas_Holder"

                        ctrl = New Gas_Holder()

                    Case "PressureStorage_Vessel"

                        ctrl = New PressureStorage_Vessel()

                    Case "Weigh_Hopper"

                        ctrl = New Weigh_Hopper()

                    Case "Delta_Connection"

                        ctrl = New Delta_Connection()

                    Case "Fuse"

                        ctrl = New Fuse()
                    
                         Case "Motor"

                        ctrl = New Motor()

                    Case "StateIndicator"

                        ctrl = New StateIndicator()

                    Case "Transformer"

                        ctrl = New Transformer()

                    Case "WYE_Connection"

                        ctrl = New WYE_Connection()

                    Case "Liquid_Filter"

                        ctrl = New Liquid_Filter()

                    Case "Vacuum_Filter"

                        ctrl = New Vacuum_Filter()

                    Case "Exchanger"

                        ctrl = New Exchanger()
                     Case "Forced_Air_Exchanged"

                        ctrl = New Forced_Air_Exchanged()

                    Case "Furnace"

                        ctrl = New Furnace()

                    Case "Rotary_Kiln"

                        ctrl = New Rotary_Kiln()

                    Case "Cooling_Tower"

                        ctrl = New Cooling_Tower()

                    Case "Evaporator"

                        ctrl = New Evaporator()

                    Case "Finned_Exchanger"

                        ctrl = New Finned_Exchanger()

                    Case "Conveyor"

                        ctrl = New Conveyor()
                     Case "Mill"

                        ctrl = New Mill()

                    Case "Roll_Stand"

                        ctrl = New Roll_Stand()

                    Case "Rotary_Feeder"

                        ctrl = New Rotary_Feeder()

                    Case "Screw_Conveyor"

                        ctrl = New Screw_Conveyor()

                    Case "Agitator"

                        ctrl = New Agitator()

                    Case "Inline_Mixer"

                        ctrl = New Inline_Mixer()

                    Case "Reciprocating_Compressor"

                        ctrl = New Reciprocating_Compressor()
                    
                     Case "Blower"

                        ctrl = New Blower()

                    Case "Compressor"

                        ctrl = New Compressor()

                    Case "Pump"

                        ctrl = New Pump()

                    Case "Turbine"

                        ctrl = New Turbine()

                    Case "Cyclone_Seperator"

                        ctrl = New Cyclone_Seperator()

                    Case "Rotary_Seperator"

                        ctrl = New Rotary_Seperator()

                    Case "Spray_Dryer"

                        ctrl = New Spray_Dryer()

                    Case Else

                        Dim controlAsm As System.Reflection.Assembly=Assembly.Load(partialName)

                        Dim controlType As Type = controlAsm.GetType(partialName & "." & ctrlName)

                        ctrl = CType(Activator.CreateInstance(controlType), Control)

                End Select

                Return ctrl

            Catch ex As Exception

                System.Diagnostics.Trace.WriteLine("create control failed:" & ex.Message)

                Return New Control()

            End Try

        End Function

 

        Public Shared Sub SetControlProperties(ByVal ctrl As Control, ByVal propertyList As Hashtable)

            Dim properties As PropertyDescriptorCollection = TypeDescriptor.GetProperties(ctrl)

            For Each myProperty As PropertyDescriptor In properties

                If propertyList.Contains(myProperty.Name) Then

                    Dim obj As Object = propertyList(myProperty.Name)

                    Try

                        myProperty.SetValue(ctrl, obj)

                    Catch ex As Exception

                        System.Diagnostics.Trace.WriteLine(ex.Message)

                    End Try

                End If

            Next myProperty

        End Sub

 

        Public Shared Function CloneCtrl(ByVal ctrl As Control) As Control

            Dim cbCtrl As CBFormCtrl = New CBFormCtrl(ctrl)

            Dim newCtrl As Control = ControlFactory.CreateControl(cbCtrl.CtrlName, cbCtrl.PartialName)

            ControlFactory.SetControlProperties(newCtrl, cbCtrl.PropertyList)

            Return newCtrl

        End Function

 

        Public Shared Sub CopyCtrl2ClipBoard(ByVal ctrl As Control)

            Dim cbCtrl As CBFormCtrl = New CBFormCtrl(ctrl)

            Dim ido As IDataObject = New DataObject()

            ido.SetData(CBFormCtrl.Format.Name, True, cbCtrl)

            Clipboard.SetDataObject(ido, False)

        End Sub
        Public Shared Function GetCtrlFromClipBoard() As Control

            Dim ctrl As Control = New Control()

            Dim ido As IDataObject = Clipboard.GetDataObject()

            If ido.GetDataPresent(CBFormCtrl.Format.Name) Then

                Dim cbCtrl As CBFormCtrl = TryCast(ido.GetData(CBFormCtrl.Format.Name), CBFormCtrl)

                ctrl = ControlFactory.CreateControl(cbCtrl.CtrlName, cbCtrl.PartialName)

                ControlFactory.SetControlProperties(ctrl, cbCtrl.PropertyList)

 

            End If

            Return ctrl

        End Function

    End Class

 

#End Region

 

          #Region "Clipboard Support"

    <Serializable()> _
    Public Class CBFormCtrl 'clipboard form control

        Private Shared format_Renamed As DataFormats.Format

        Private ctrlName_Renamed As String

        Private partialName_Renamed As String

        Private propertyList_Renamed As Hashtable = New Hashtable()

        Shared Sub New()

            ' Registers a new data format with the windows Clipboard

            format_Renamed = DataFormats.GetFormat(GetType(CBFormCtrl).FullName)

        End Sub

        Public Shared ReadOnly Property Format() As DataFormats.Format

            Get

                Return format_Renamed

            End Get

        End Property

        Public Property CtrlName() As String

            Get

                Return ctrlName_Renamed

            End Get

            Set(ByVal value As String)

                ctrlName_Renamed = value

            End Set

        End Property

 

        Public Property PartialName() As String

            Get

                Return partialName_Renamed

            End Get

            Set(ByVal value As String)

                partialName_Renamed = value

            End Set

        End Property

 

        Public ReadOnly Property PropertyList() As Hashtable

            Get

                Return propertyList_Renamed

            End Get

        End Property

 

        Public Sub New(ByVal ctrl As Control)

            CtrlName = ctrl.GetType().Name

            PartialName = ctrl.GetType().Namespace

            Dim properties As PropertyDescriptorCollection = TypeDescriptor.GetProperties(ctrl)

            For Each myProperty As PropertyDescriptor In properties

                Try

                    If myProperty.PropertyType.IsSerializable Then

                        propertyList_Renamed.Add(myProperty.Name, myProperty.GetValue(ctrl))

                    End If

                Catch ex As Exception

                    System.Diagnostics.Trace.WriteLine(ex.Message)

                    'do nothing, just continue

                End Try

            Next myProperty

        End Sub

    End Class

#End Region

End Namespace


